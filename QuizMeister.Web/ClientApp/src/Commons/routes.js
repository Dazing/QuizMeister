import DefaultPage from "../Pages/DefaultPage/DefaultPage";
import HomePage from '../Pages/HomePage/HomePage';
import ScorePage from '../Pages/ScorePage/ScorePage';

const routes = [
  {
    path: '/:sessionId/score',
    component: ScorePage
  },
  {
    path: '/',
    component: HomePage
  },
  {
    path: '*',
    component: DefaultPage
  },
];

export default routes;
