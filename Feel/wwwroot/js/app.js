// CHIUSURA DEL MODALE IN FASE DI VALIDAZIONE
window.closeModalById = (modalId) => {
    const modalEl = document.getElementById(modalId);
    if (modalEl) {
        const modal = bootstrap.Modal.getOrCreateInstance(modalEl); 
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

// CAMBIA IL TEMA

window.ThemeCarouselInterop = {
    startListening: function (dotNetHelper) {
        const carousel = document.getElementById("themeCarousel");
        if (!carousel) {
            console.log("Carosello non trovato");
            return;
        }

        const instance = bootstrap.Carousel.getInstance(carousel);
        if (!instance) {
            new bootstrap.Carousel(carousel, {
                interval: false,
                ride: false
            });
        }

        carousel.addEventListener('slid.bs.carousel', function () {
            const active = carousel.querySelector('.carousel-item.active');
            if (!active) return;

            const index = parseInt(active.getAttribute('data-bs-theme-index'));
            if (!isNaN(index)) {
                dotNetHelper.invokeMethodAsync("AggiornaTemaDaIndice", index);
            }
        });
    }
};



