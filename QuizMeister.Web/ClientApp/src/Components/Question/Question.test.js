import Enzyme, { shallow } from 'enzyme';
import Adapter from 'enzyme-adapter-react-16';
import React from 'react';
import Question from './Question';

Enzyme.configure({ adapter: new Adapter() })

const question = {
  "id": 5,
  "questionText": "Which year did the JavaScript programming languege appear for the first time?",
  "answers": [
    {
      "id": 13,
      "option": "A",
      "text": "1995"
    },
    {
      "id": 14,
      "option": "B",
      "text": "2000"
    },
    {
      "id": 15,
      "option": "C",
      "text": "1998"
    },
    {
      "id": 16,
      "option": "D",
      "text": "2010"
    }
  ],
  "hasNext": true
};

describe('Question', () => {
  const wrapper = shallow(<Question question={question} />)

  it('renders all options', () => {
    const inputs = wrapper.find('Radio');
    expect(inputs.length).toEqual(question.answers.length);
  });
  it('renders question text', () => {
    const questionText = wrapper.find('h3');
    expect(questionText.text()).toEqual(question.questionText);
  });
});
