import { Button, Col, Divider, notification, Row, Space, Spin } from 'antd';
import React, { useEffect, useState } from 'react';
import QuizAPI from '../../API/QuizAPI';
import Question from '../../Components/Question/Question';

const HomePage = ({ history }) => {
  const [loadingSessionId, setLoadingSessionId] = useState(true);
  const [sessionId, setSessionId] = useState();

  const [loadingQuestion, setLoadingQuestion] = useState(false);
  const [question, setQuestion] = useState();

  const [postingAnswer, setPostingAnswer] = useState(false);
  const [answer, setAnswer] = useState();
  const [endOfQuiz, setEndOfQuiz] = useState(false);

  const [answeredQuestions, setAnsweredQuestions] = useState(0);

  const [error, setError] = useState(null);


  useEffect(() => {
    if (loadingSessionId) {
      QuizAPI.getSessionId()
        .then(_ => setSessionId(_))
        .catch(error => setError(error));
    }
  }, [loadingSessionId]);
  useEffect(() => {
    if (sessionId) {
      setLoadingSessionId(false);
      setLoadingQuestion(true);
    };
  }, [sessionId]);

  useEffect(() => {
    if (loadingQuestion) {
      QuizAPI.getNextQuestion(sessionId)
        .then(_ => setQuestion(_))
        .catch(error => setError(error));
    }
  }, [loadingQuestion]); // eslint-disable-line react-hooks/exhaustive-deps
  useEffect(() => {
    if (question) { setLoadingQuestion(false) };
  }, [question]);

  useEffect(() => {
    if (error)
      notification.error({
        message: error.header,
        description: error.message,
      });
  }, [error]);

  useEffect(() => {
    if (postingAnswer) {
      QuizAPI.postAnswer(sessionId, question.id, { answerId: answer })
        .then(_ => setAnswer(null))
        .catch(error => setError(error));
    }
  }, [postingAnswer]); // eslint-disable-line react-hooks/exhaustive-deps

  useEffect(() => {
    if (!answer && postingAnswer) {
      setPostingAnswer(false);
      setAnsweredQuestions(answeredQuestions + 1)

      if (question && question.hasNext) setLoadingQuestion(true)
      else if (question && !question.hasNext) setEndOfQuiz(true)
    }
  }, [answer]); // eslint-disable-line react-hooks/exhaustive-deps

  const onChangeAnswer = (e, value) => setAnswer(e.target.value)


  const renderContent = () => {
    if (endOfQuiz) {
      return (
        <Col span={12}>
          <Row>
            <h3>Quiz completed!</h3>
          </Row>
          <Row>
            <Button
              type="primary"
              loading={postingAnswer}
              style={{ float: 'right' }}
              onClick={() => history.push('/' + sessionId + '/score')}
            >
              View Score
          </Button>
          </Row>
        </Col>
      )
    }
    return (
      <Spin spinning={loadingQuestion || loadingSessionId}>
        <Col span={12}>
          <Row>
            <Question
              question={question}
              answer={answer}
              onChangeAnswer={onChangeAnswer}
            />
          </Row>
          <Divider orientation="left" plain>
            Actions
          </Divider>
          <Row>
            <Space size="middle">
              <Button
                type="primary"
                loading={postingAnswer}
                style={{ float: 'right' }}
                onClick={() => setPostingAnswer(true)}
              >
                Submit Answer
              </Button>
              {
                answeredQuestions >= 3
                  ? (
                    <Button
                      type="primary"
                      loading={postingAnswer}
                      style={{ float: 'right' }}
                      onClick={() => history.push('/' + sessionId + '/score')}
                    >
                      View Score
                    </Button>
                  ) : null
              }
            </Space>
          </Row>
        </Col>
      </Spin>
    );
  }

  return (
    <div className="app-page">
      <div className="app-page-content" id="app-home-page">
        {
          renderContent()
        }
      </div>
    </div>
  );
};

export default HomePage;
