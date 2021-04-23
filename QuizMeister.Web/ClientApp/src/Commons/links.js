import { faBook, faBriefcase, faCalendar, faHome, faTasks } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import React from 'react';


const links = [
  {
    path: '/',
    name: 'Home',
    icon: <FontAwesomeIcon icon={faHome} />,
  },
  {
    path: '/orders',
    name: 'Orders',
    icon: <FontAwesomeIcon icon={faBook} />,
    subLinks: [
      {
        path: '/orders/daily',
        name: 'Daily',
      },
      {
        path: '/orders/weekly',
        name: 'Weekly',
      },
      {
        path: '/orders/monthly',
        name: 'Monthly',
      },
    ]
  },
  {
    path: '/calendar',
    name: 'Calendar',
    icon: <FontAwesomeIcon icon={faCalendar} />,
  },
  {
    path: '/tasks',
    name: 'Tasks',
    icon: <FontAwesomeIcon icon={faTasks} />,
  },
  {
    path: '/projects',
    name: 'Projects',
    icon: <FontAwesomeIcon icon={faBriefcase} />,
  }
];

export default links;
