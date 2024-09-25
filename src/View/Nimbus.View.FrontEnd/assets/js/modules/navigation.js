const navigation = document.querySelector('.nimbus__navigation');
let showMenuTimer;

/**
 * Shows the application menu and resets the timer
 * for hiding it.
 */
const showMenu = () => {
    clearTimeout(showMenuTimer);
    navigation?.classList.add('nimbus__navigation--active');
};

/**
 * Hides the application menu, if the mouse has
 * left the window entirely.
 * @param {MouseEvent} mouseEvent 
 */
const hideMenuWithDelay = (mouseEvent) => {
    if(mouseEvent.relatedTarget) {
        return;
    }

    showMenuTimer = setTimeout(() => navigation?.classList.remove('nimbus__navigation--active'), 3000);
};

/**
 * Initializes the navigation.
 */
export const init = () => {
    if(!navigation) {
        return;
    }

    const minimizeButton = navigation?.querySelector('.nimbus__navigation-button--minimize');
    const maximizeButton = navigation?.querySelector('.nimbus__navigation-button--maximize');
    const closeButton = navigation?.querySelector('.nimbus__navigation-button--close');
    
    minimizeButton?.addEventListener('click', async () => await window.nimbusMenu.minimize());
    maximizeButton?.addEventListener('click', async () => await window.nimbusMenu.maximize());
    closeButton?.addEventListener('click', async () => await window.nimbusMenu.close());
    document.addEventListener('mouseenter', showMenu);
    document.addEventListener('mouseleave', hideMenuWithDelay);
};