import { faCompass } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import React from 'react';
import './defaultpage.scss';


const DefaultPage = () => {
  return (
    <div className="app-page">
      <div className="app-page-content" id="app-default-page">
        <h1>Page not Found</h1>
        <FontAwesomeIcon icon={faCompass} className="default-page-icon" size="10x" />
      </div>
    </div>
  );
};

export default DefaultPage;
