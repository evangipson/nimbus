import { getCurrentWeather } from '../api/weather.js';
import { createWeatherIcon } from '../factories/weatherIconFactory.js';

/**
 * Gets the current weather from the weather api, then updates
 * the application to show the current weather.
 */
export const init = () => {
	const temperatureElement = document.querySelector('.nimbus__weather-temperature');
	const weatherIconWrapperElement = document.querySelector('.nimbus__weather-image');

	getCurrentWeather().then(weatherResponse => {
		const newWeatherIcon = createWeatherIcon(
			weatherResponse.precipitationChance,
			weatherResponse.cloudCover,
			weatherResponse.windSpeed,
			weatherResponse.isDay
		);
		weatherIconWrapperElement.innerHTML = '';
		newWeatherIcon.forEach(icon => weatherIconWrapperElement.appendChild(icon));

		temperatureElement.textContent = `${weatherResponse.temperature}${weatherResponse.temperatureUnit}`;
	});
};