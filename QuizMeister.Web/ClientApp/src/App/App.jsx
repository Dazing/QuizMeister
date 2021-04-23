/* eslint-enable no-unused-vars */
import React from 'react';
/* eslint-disable no-unused-vars */
import { Route, Switch, withRouter } from 'react-router-dom';
import routes from '../Commons/routes';
import './app.scss';


const App = () => {
  return (
    <div id="app">
      <div id="app-content">
        {
          <Switch>
            {
              routes.map((route, index) => {
                const key =`route-${index}`;
                return (<Route key={key} strict exact {...route} />);
              })
            }
          </Switch>
        }
      </div>

    </div>
  );
}

export default withRouter(App);
