import { Divider, Radio } from 'antd';
import React from 'react';

const radioStyle = {
  display: 'block',
  height: '30px',
  lineHeight: '30px',
};

const Question = ({ question, answer, onChangeAnswer }) => (
  <div>
    <h3>
      {question && question.questionText}
    </h3>
    <Divider orientation="left" plain>
      Options
    </Divider>
    <Radio.Group onChange={onChangeAnswer} value={answer}>
      {
        question && question.answers.map(_ => (
          <Radio key={_.id} style={radioStyle} value={_.id}>
            {_.option}: {_.text}
          </Radio>
        ))
      }
    </Radio.Group>
  </div>
);

export default Question;
