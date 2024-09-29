const getCloudLayer = (precipitationChance, cloudCover) => {
    const iconMap = {
        'cloudy': 'fa-cloud',
        'rain': 'fa-cloud-showers-heavy',
    };

    if(precipitationChance > 0.6) {
        return iconMap['rain'];
    }
    return cloudCover > 0.6 && iconMap['cloudy'];
};

const getWindLayer = (windSpeed) => windSpeed > 5 && 'fa-wind';

const getSkyLayer = (isDay = false) => isDay ? 'fa-sun' : 'fa-moon';

export const createWeatherIcon = (precipitationChance, cloudCover, windSpeed, isDay = false) => {
    const iconBaseStyle = 'fa-solid';
    const nimbusIconClass = 'nimbus__weather-icon';
    const skyLayer = { 'name': 'sky' };
    const cloudLayer = { 'name': 'cloud' };
    const windLayer = { 'name': 'wind' };
    let weatherIconLayers = [skyLayer, windLayer, cloudLayer];

    skyLayer.className = getSkyLayer(isDay);
    cloudLayer.className = getCloudLayer(precipitationChance, cloudCover);
    windLayer.className = getWindLayer(windSpeed);

    return weatherIconLayers.filter(icon => icon).map(icon => {
        const iconLayer = document.createElement('i');
        iconLayer.classList.add(nimbusIconClass, iconBaseStyle, icon.className);
        iconLayer.setAttribute('data-layer', icon.name);
        return iconLayer;
    });
};