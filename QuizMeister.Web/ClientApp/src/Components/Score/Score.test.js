import Enzyme, { shallow } from 'enzyme';
import Adapter from 'enzyme-adapter-react-16';
import React from 'react';
import Score from './Score';

Enzyme.configure({ adapter: new Adapter() })

describe('Score', () => {
  const wrapper = shallow(<Score score={2} />)

  it('renders score', () => {
    expect(wrapper.find('Result').props().title.includes('Your score was 2!')).toBe(true);
  });
});
