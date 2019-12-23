import React from 'react';
import { Route, Switch } from 'react-router-dom';
import EmptyWorkspace from '../layout/workspace/EmptyWorkspace';
import UserContentContainer from '../pages/user-content/UserContentContainer';

export const routes = {
  content: '/content'
};

export const RouteProvider = () => {
  return (
    <Switch>
      <Route path={routes.content}>
        <UserContentContainer />
      </Route>
      <EmptyWorkspace />
    </Switch>
  );
};

export default RouteProvider;
