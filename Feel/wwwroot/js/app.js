// CHIUSURA DEL MODALE IN FASE DI VALIDAZIONE

window.closeModalById = (modalId) => {
    const modalEl = document.getElementById(modalId);
    if (modalEl) {
        const modal = bootstrap.Modal.getInstance(modalEl) || new bootstrap.Modal(modalEl);
        modal.hide();
    }
};


