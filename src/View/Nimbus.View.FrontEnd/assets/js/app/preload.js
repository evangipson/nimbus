const { contextBridge, ipcRenderer } = require('electron/renderer');

contextBridge.exposeInMainWorld('nimbusMenu', {
    minimize: () => ipcRenderer.invoke('app:minimize'),
    maximize: () => ipcRenderer.invoke('app:maximize'),
    close: () => ipcRenderer.invoke('app:close'),
});