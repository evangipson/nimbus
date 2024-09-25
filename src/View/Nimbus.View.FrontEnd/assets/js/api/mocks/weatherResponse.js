/**
 * Gets a mocked response for the current weather.
 * @param {string} time 
 * @param {number} temperature 
 * @param {number} relative_humidity 
 * @param {number} is_day 
 * @param {number} precipitation 
 * @param {number} cloud_cover 
 * @param {number} wind_speed 
 * @param {number} wind_direction 
 * @returns {Object} a mocked weather response.
 */
export const getMockedWeatherResponse = (
    time = '2024-01-01T00:00',
    temperature = 50,
    relative_humidity = 10,
    is_day = true,
    precipitation = 0.0,
    cloud_cover = 40,
    wind_speed = 10,
    wind_direction = 180,
) => {
    return {
        time,
        temperature,
        relative_humidity,
        is_day,
        precipitation,
        cloud_cover,
        wind_speed,
        wind_direction,
    };
};