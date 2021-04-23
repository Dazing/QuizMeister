export const BadRequest = message => ({
  type: 'BadRequest',
  isGlobalError: false,
  header: 'Bad Request',
  message: message || '',
});

export const ResourceNotFound = message => ({
  type: 'ResourceNotFound',
  isGlobalError: false,
  header: 'Resource Not Found',
  message: message || 'The requested resource was not found.',
});

export const ServerError = message => ({
  type: 'ServerError',
  isGlobalError: false,
  header: 'Server Error',
  message: message && message.length < 400 ? message : 'A Server Error occured, please try again later.',
});

export const UnknowError = message => ({
  type: 'UnknowError',
  isGlobalError: false,
  header: ' Unknow Error',
  message: message || 'An Unknow Error occured, please try again later.',
});

export const GenerateException = (response, errorBody) => {
  switch (response.status) {
    case 400:
      return BadRequest(errorBody);
    case 404:
      return ResourceNotFound(errorBody);
    case 500:
      return ServerError(errorBody);
    default:
      return UnknowError(errorBody);
  }
};

export const ValidateResponse = (response, entityId) => {
  if (!response.ok) {
    return response.text().then((errorBody) => {
      const exception = GenerateException(response, errorBody);
      exception.entityId = entityId || undefined;
      throw exception;
    });
  }
  return response.headers.get("Content-Type") ? response.json() : null;
};
