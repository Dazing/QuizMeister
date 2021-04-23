import { Result } from 'antd';
import React from 'react';

const Score = ({ score }) => (
  <div>
    <Result
      status="success"
      title={'Your score was ' + score + '!'}
      subTitle='Good job on answering the quiz!'
    />

  </div>
);

export default Score;
