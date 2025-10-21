// Client/Services/ToastService.cs
// Servicio simple para mostrar notificaciones tipo "toast" en la UI.
// Mantén este servicio registrado como singleton para usarlo desde cualquier componente.

using System;

namespace IspManagementERP.Client.Services
{
    public class ToastService
    {
        // evento: mensaje y tipo ("success" | "danger" | "info" | ...)
        public event Action<string, string>? OnShow;
        public event Action? OnHide;

        // Mostrar toast con tipo por defecto "info"
        public void ShowToast(string mensaje, string tipo = "info")
        {
            OnShow?.Invoke(mensaje, tipo);
        }

        public void ShowSuccess(string mensaje) => ShowToast(mensaje, "success");
        public void ShowError(string mensaje) => ShowToast(mensaje, "danger");

        public void Hide()
        {
            OnHide?.Invoke();
        }
    }
}