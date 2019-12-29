import React from 'react';
import { Route, Switch } from 'react-router-dom';
import EmptyWorkspace from '../layout/workspace/EmptyWorkspace';
import { HelpContainer } from '../pages/help/HelpContainer';
import RecipeContainer from '../pages/recipes/RecipeContainer';
import UserContentContainer from '../pages/user-content/UserContentContainer';

export const routes = {
  attributes: '/attributes',
  content: '/content',
  help: '/help',
  recipes: '/recipes',
  traits: '/traits'
};

export const RouteProvider = () => {
  return (
    <Switch>
      <Route path={routes.content}>
        <UserContentContainer />
      </Route>
      <Route path={routes.recipes}>
        <RecipeContainer />
      </Route>
      <Route path={routes.help}>
        <HelpContainer />
      </Route>
      <EmptyWorkspace />
    </Switch>
  );
};

export default RouteProvider;
