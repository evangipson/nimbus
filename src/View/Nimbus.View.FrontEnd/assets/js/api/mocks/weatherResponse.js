/**
 * Gets a mocked weather forecast api response.
 * @param {string} date 
 * @param {number} temperature 
 * @param {string} temperatureUnit 
 * @param {number} humidity 
 * @param {string} humidityUnit 
 * @param {boolean} isDay 
 * @param {number} precipitationChance 
 * @param {string} precipitationUnit 
 * @param {number} cloudCover 
 * @param {string} cloudCoverUnit 
 * @param {number} windSpeed 
 * @param {string} windSpeedUnit 
 * @param {number} windDirection 
 * @param {string} windDirectionUnit 
 * @returns {object} a mocked api weather forecast response.
 */
export const getMockedWeatherResponse = (
    date = '2024-01-01T00:00',
    temperature = 50,
    temperatureUnit = '°',
    humidity = 10,
    humidityUnit = '%',
    isDay = true,
    precipitationChance = 0.8,
    precipitationUnit = 'mm',
    cloudCover = 80,
    cloudCoverUnit = '%',
    windSpeed = 10,
    windSpeedUnit = 'km/h',
    windDirection = 180,
    windDirectionUnit = '°',
) => {
    return {
        date,
        temperature,
        temperatureUnit,
        humidity,
        humidityUnit,
        isDay,
        precipitationChance,
        precipitationUnit,
        cloudCover,
        cloudCoverUnit,
        windSpeed,
        windSpeedUnit,
        windDirection,
        windDirectionUnit,
    };
};