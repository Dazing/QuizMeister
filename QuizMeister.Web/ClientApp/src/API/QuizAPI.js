import httpRequest from './HttpService';

const QuizAPI = {
  getSessionId: () => httpRequest('GET', '/api/quiz/start'),
  getNextQuestion: (sessionId) => httpRequest('GET', `/api/quiz/${sessionId}/questions/next`),
  getScore: (sessionId) => httpRequest('GET', `/api/quiz/${sessionId}/score`),

  postAnswer: (sessionId, questionId, payload) => httpRequest('POST', `/api/quiz/${sessionId}/questions/${questionId}/answer`, payload),
}

export default QuizAPI;
