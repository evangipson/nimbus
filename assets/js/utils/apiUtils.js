/**
 * Will fake a server response time. Used in the case of
 * mocked responses.
 * @param {Number} timeToWait - the amount of time to wait,
 * in milliseconds, defaults to 1000 milliseconds.
 */
const fakeServerResponseTime = async (timeToWait = 1500) => {
    await new Promise(fakeServerResponse => setTimeout(fakeServerResponse, timeToWait));
};

/**
 * Will GET a URL and return the raw response.
 * @param {String} urlToGet 
 * @returns the response or false
 */
const get = async(urlToGet) => await fetch(urlToGet, { method: 'GET' })
    .then(response => response)
    .catch(() => false);

/**
 * Will `GET` a URL, and attempts to create JSON out
 * of the response, then returns it if everything
 * was successful.
 * @param {String} urlToGet 
 * @param {Object} [mockedResponse] - a mocked response,
 * `false` by default. if provided, this function will return
 * the `mockedResponse` before attempting the `GET`.
 * @returns {JSON|{}} the `mockedResponse` if one is provided.
 * Otherwise, returns the JSON response from the `GET`,
 * or an empty object if the `GET` was unsuccessful.
 */
export const getResponseFromGet = async (urlToGet, mockedResponse = false) => {
    if(mockedResponse) {
        /* Fake a server response by delaying the return slightly.
         * This is to see any loading animations happen. */
        await fakeServerResponseTime();
        return mockedResponse;
    }

    let postResponseJSON;
    const postResponse = await get(urlToGet);

    if(postResponse?.ok) {
        postResponseJSON = await postResponse.json();
    }

    return postResponseJSON || {};
};