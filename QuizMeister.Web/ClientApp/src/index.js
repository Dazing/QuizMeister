import 'promise-polyfill/src/polyfill';
import React from 'react';
import { render } from 'react-dom';
import {
  BrowserRouter as Router
} from 'react-router-dom';
import 'whatwg-fetch';
import App from './App/App';

const MOUNT_NODE = document.getElementById('root');

render(
  <Router strict>
    <App />
  </Router>,
  MOUNT_NODE,
);
