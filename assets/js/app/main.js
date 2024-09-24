const { app, BrowserWindow, Menu, ipcMain } = require('electron');
const path = require('node:path');

const setupMenuEvents = (mainWindow) => {
    ipcMain.handle('app:close', app.quit);
    ipcMain.handle('app:minimize', mainWindow.minimize);
    ipcMain.handle('app:maximize', () => {
        mainWindow.isMaximized()
            ? mainWindow.restore()
            : mainWindow.maximize();
    });
};

const createElectronWindow = () => {
    const mainWindow = new BrowserWindow({
        width: 800,
        height: 600,
        vibrancy: 'fullscreen-ui',
        backgroundMaterial: 'acrylic',
        webPreferences: {
            preload: path.join(__dirname, 'preload.js'),
        },
        titleBarStyle: 'acrylic',
        frame: false,
        show: false,
    });
    
    setupMenuEvents(mainWindow);
    mainWindow.setMinimumSize(350, 350);
    mainWindow.loadFile('../../../index.html');
    mainWindow.once('ready-to-show', mainWindow.show);
    mainWindow.webContents.openDevTools();
};

Menu.setApplicationMenu(false);

app.whenReady().then(() => {
    createElectronWindow();
    app.on('activate', () => !BrowserWindow.getAllWindows().length && createElectronWindow());
});

app.on('window-all-closed', () => process.platform !== 'darwin' && app.quit());