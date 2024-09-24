import { getCurrentWeather } from '../api/weather.js';

/**
 * Gets the current weather from the weather api, then updates
 * the application to show the current weather.
 */
export const init = () => {
	const temperatureElement = document.querySelector('.nimbus__weather-temperature');
	getCurrentWeather().then(weatherResponse => {
		temperatureElement.textContent = `${weatherResponse.temperature}°`;
	});
};