// wwwroot/service-worker.js

self.addEventListener('install', event => {
    console.log('[SW] install');
    // niente caching in install
});

self.addEventListener('activate', event => {
    console.log('[SW] activate');
    // Prende subito il controllo sui client
    event.waitUntil(self.clients.claim());
});

// Nessuna logica di fetch: sempre in network-only
self.addEventListener('fetch', () => { });

self.addEventListener('message', event => {
    if (event.data?.type === 'SKIP_WAITING') {
        console.log('[SW] skipWaiting ricevuto');
        self.skipWaiting();
    }
});
