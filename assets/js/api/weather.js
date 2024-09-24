const ApiUtils = require('../utils/apiUtils');
const MockWeather = require('./mocks/weatherResponse');

/**
 * Gets the current weather from the API.
 * @returns {Object} the current weather.
 */
export const getCurrentWeather = () => {
    const mockedWeatherResponse = MockWeather.getMockedWeatherResponse();
    const weatherResponse = ApiUtils.getResponseFromGet('/weather', mockedWeatherResponse);

    return weatherResponse;
};