import { getResponseFromGet } from '../utils/apiUtils.js';
import { getMockedWeatherResponse } from './mocks/weatherResponse.js';

/**
 * Gets the current weather from the API.
 * @returns {Object} the current weather.
 */
export const getCurrentWeather = async () => {
    const mockedWeatherResponse = getMockedWeatherResponse();
    const weatherResponse = await getResponseFromGet('/weather', mockedWeatherResponse);

    return weatherResponse;
};