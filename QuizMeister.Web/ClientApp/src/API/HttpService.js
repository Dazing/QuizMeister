import { ValidateResponse } from './Exceptions';

const baseUrl = window.location.origin;

const HttpService = async (method, endpoint, payload) => fetch(`${baseUrl}${endpoint}`, {
  method,
  headers: {
    'Content-Type': 'application/json',
  },
  body: payload ? JSON.stringify(payload) : null,
})
  .then(response => ValidateResponse(response))
  .catch((error) => { throw error; })
  .then(response => response);

export default HttpService;
