const { app, BrowserWindow, Menu, ipcMain, session } = require('electron');
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
    session.fromPartition("default").setPermissionRequestHandler((webContents, permission, callback) => {
        let allowedPermissions = ["geolocation"];

        if (allowedPermissions.includes(permission)) {
            callback(true); // Approve permission request
        } else {
            console.error(`The application tried to request permission for '${permission}'. This permission was not whitelisted and has been blocked.`);
            callback(false); // Deny
        }
    });
    mainWindow.webContents.openDevTools();
};

Menu.setApplicationMenu(false);

app.whenReady().then(() => {
    createElectronWindow();
    app.commandLine.appendSwitch('enable-features', 'WinrtGeolocationImplementation');
    app.on('activate', () => !BrowserWindow.getAllWindows().length && createElectronWindow());
});

app.on('window-all-closed', () => process.platform !== 'darwin' && app.quit());