// CHIUSURA DEL MODALE IN FASE DI VALIDAZIONE

window.closeModalById = (modalId) => {
    const modalEl = document.getElementById(modalId);
    if (modalEl) {
        const modal = bootstrap.Modal.getInstance(modalEl) || new bootstrap.Modal(modalEl);
        modal.hide();
    }
};

// APERTURA MODALE

window.showModalById = (modalId) => {
    const modalEl = document.getElementById(modalId);
    if (modalEl) {
        const instance = bootstrap.Modal.getOrCreateInstance(modalEl);
        instance.show();
    }
};


// APRE IL MODAL NEL DIV CHE DECIDO IO COSI DA EVITARE CHE SI APRA IN ALTRI POSTI

window.moveModalToContainer = (modalId, containerId = 'modal-container') => {
    const modal = document.getElementById(modalId);
    const container = document.getElementById(containerId);
    if (modal && container && !container.contains(modal)) {
        container.appendChild(modal);
    }
    bootstrap.Modal.getOrCreateInstance(modal);
};



