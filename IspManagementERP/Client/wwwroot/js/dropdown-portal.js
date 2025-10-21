// Client/wwwroot/js/dropdown-portal.js
// Mueve el .dropdown-menu al <body> mientras el dropdown está abierto
// y lo posiciona con Popper para evitar que se recorte por contenedores con overflow.
//
// Requisitos:
// - bootstrap.bundle (incluye Popper) debe cargarse antes de este script.
// - Cargar este script antes de blazor.webassembly.js (o blazor.server.js).

(function () {
    // Guardamos datos por cada menu para restaurarlo correctamente
    var store = new WeakMap();

    // Obtener createPopper de Popper (compatible con distintas bundlings)
    var createPopperFn = null;
    if (window.Popper && window.Popper.createPopper) {
        createPopperFn = window.Popper.createPopper;
    } else if (window.createPopper) {
        createPopperFn = window.createPopper;
    } else if (window.bootstrap && window.bootstrap.Popover && window.bootstrap.Popover._createPopper) {
        // fallback extraño, raro en bundle oficial
        createPopperFn = window.bootstrap.Popover._createPopper;
    } else if (window.bootstrap && window.bootstrap.Dropdown && window.bootstrap.Dropdown.prototype && window.bootstrap.Dropdown.prototype._createPopper) {
        createPopperFn = window.bootstrap.Dropdown.prototype._createPopper;
    }

    function findMenu(dropdownEl) {
        if (!dropdownEl) return null;
        return dropdownEl.querySelector('.dropdown-menu');
    }

    function findToggle(dropdownEl) {
        if (!dropdownEl) return null;
        // botón que tiene data-bs-toggle="dropdown"
        return dropdownEl.querySelector('[data-bs-toggle="dropdown"]');
    }

    function onShow(ev) {
        try {
            var dropdownEl = ev.target; // el elemento .dropdown (o contenedor)
            var menu = findMenu(dropdownEl);
            var toggle = findToggle(dropdownEl);

            if (!menu || !toggle) return;

            // si ya movido, no hacer nada
            if (store.has(menu)) return;

            // Guardar referencia para restaurar
            var info = {
                originalParent: menu.parentNode,
                nextSibling: menu.nextSibling,
                popperInstance: null
            };
            store.set(menu, info);

            // Mover el menu al body para evitar recorte por overflow
            document.body.appendChild(menu);

            // Crear instancia de Popper si está disponible
            if (createPopperFn) {
                // preferir placement 'bottom-end' para alineado a la derecha del toggle
                try {
                    info.popperInstance = createPopperFn(toggle, menu, {
                        placement: 'bottom-end',
                        modifiers: [
                            { name: 'offset', options: { offset: [0, 6] } },
                            { name: 'preventOverflow', options: { boundary: 'viewport' } },
                            { name: 'computeStyles', options: { adaptive: true } }
                        ]
                    });
                } catch (e) {
                    console.warn('dropdown-portal: createPopper error', e);
                }
            } else {
                // Si no hay Popper, intentamos posicionarlo manualmente (fallback)
                var rect = toggle.getBoundingClientRect();
                menu.style.position = 'absolute';
                menu.style.top = (rect.bottom + window.scrollY) + 'px';
                menu.style.left = (rect.right - menu.offsetWidth + window.scrollX) + 'px';
            }

            // Asegurar clase para z-index
            menu.classList.add('dropdown-portal-open');
        } catch (err) {
            console.warn('dropdown-portal show handler error', err);
        }
    }

    function onHidden(ev) {
        try {
            var dropdownEl = ev.target;
            var menu = findMenu(dropdownEl);
            if (!menu || !store.has(menu)) return;

            var info = store.get(menu);

            // Destruir popper si existe
            try {
                if (info.popperInstance && typeof info.popperInstance.destroy === 'function') {
                    info.popperInstance.destroy();
                }
            } catch (e) { /* ignore */ }

            // Restaurar menú en su lugar original
            if (info.originalParent) {
                if (info.nextSibling && info.nextSibling.parentNode === info.originalParent) {
                    info.originalParent.insertBefore(menu, info.nextSibling);
                } else {
                    info.originalParent.appendChild(menu);
                }
            }

            // Limpiar estilos/clases temporales
            menu.style.position = '';
            menu.style.top = '';
            menu.style.left = '';
            menu.classList.remove('dropdown-portal-open');

            store.delete(menu);
        } catch (err) {
            console.warn('dropdown-portal hidden handler error', err);
        }
    }

    // Registrar listeners cuando DOM listo
    document.addEventListener('DOMContentLoaded', function () {
        // Si bootstrap no está presente, no hacemos nada (defensivo)
        if (!window.bootstrap && !createPopperFn) {
            // aún así funciona el fallback absoluto si bootstrap no existe,
            // pero recomendamos cargar bootstrap.bundle antes de este script.
            // No lanzamos error para no romper la app.
        }

        document.addEventListener('show.bs.dropdown', onShow);
        document.addEventListener('hidden.bs.dropdown', onHidden);
    });
})();