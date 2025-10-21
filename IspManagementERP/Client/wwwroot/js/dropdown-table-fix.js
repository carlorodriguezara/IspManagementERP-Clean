// Client/wwwroot/js/dropdown-table-fix.js
// Script que hace overflow: visible al contenedor .table-responsive
// mientras un dropdown dentro de él está abierto, para evitar que el menú
// quede recortado en dispositivos móviles o monitor pequeño.

(function () {
    // Esperar a que el DOM esté listo
    document.addEventListener('DOMContentLoaded', function () {
        // Escuchar evento global de Bootstrap cuando un dropdown se muestra
        document.addEventListener('show.bs.dropdown', function (ev) {
            try {
                // ev.target es el elemento .dropdown o el toggle dependiendo del caso
                var toggle = ev.target;
                // buscar el contenedor table-responsive más cercano
                var tableResp = toggle.closest ? toggle.closest('.table-responsive') : null;
                if (tableResp) {
                    tableResp.classList.add('dropdown-open'); // clase que hará overflow:visible
                }
            } catch (e) {
                // no bloquear si hay error
                console.warn('dropdown-table-fix: show handler error', e);
            }
        });

        // Al cerrar, quitar la clase
        document.addEventListener('hidden.bs.dropdown', function (ev) {
            try {
                var toggle = ev.target;
                var tableResp = toggle.closest ? toggle.closest('.table-responsive') : null;
                if (tableResp) {
                    tableResp.classList.remove('dropdown-open');
                }
            } catch (e) {
                console.warn('dropdown-table-fix: hidden handler error', e);
            }
        });
    });
})();