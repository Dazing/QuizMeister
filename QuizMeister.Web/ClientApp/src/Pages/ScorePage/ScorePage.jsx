import { notification, Spin } from 'antd';
import React, { useEffect, useState } from 'react';
import QuizAPI from '../../API/QuizAPI';
import Score from '../../Components/Score/Score';

const ScorePage = ({ match }) => {
  const [loadingScore, setLoadingScore] = useState(true);
  const [score, setScore] = useState();

  const [error, setError] = useState(null);

  useEffect(() => {
    if (error)
      notification.error({
        message: error.header,
        description: error.message,
      });
  }, [error]);

  useEffect(() => {
    if (loadingScore) {
      QuizAPI.getScore(match.params.sessionId)
        .then(_ => setScore(_))
        .catch(error => setError(error));
    }
  }, [loadingScore]); // eslint-disable-line react-hooks/exhaustive-deps
  useEffect(() => {
    if (score) { setLoadingScore(false) };
  }, [score]);

  return (
    <div className="app-page">
      <div className="app-page-content">
        <Spin spinning={loadingScore}>
          <Score score={score} />
        </Spin>
      </div>
    </div>
  );
};

export default ScorePage;
