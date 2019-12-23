import { createStyles, makeStyles } from '@material-ui/core';
import React from 'react';
import CommandMenu from './layout/CommandMenu';
import Header from './layout/Header';
import Workspace from './layout/Workspace';
import RollProviders from './providers/RollProviders';
import DefaultTheme from './styles/DefaultTheme';

const menuWidth = '250px';

const useStyles = makeStyles(theme =>
  createStyles({
    appContainer: {
      height: '100vh',
      width: '100vw'
    },
    workspaceContainer: {
      marginLeft: menuWidth
    },
    menuDrawer: {},
    headerSpacer: theme.mixins.toolbar
  })
);

const App: React.FC = () => {
  const classes = useStyles();
  return (
    <RollProviders theme={DefaultTheme}>
      <div className={classes.appContainer}>
        <Header />
        <CommandMenu className={`${classes.menuDrawer} ${classes.headerSpacer}`} menuWidth={menuWidth} />
        <Workspace className={`${classes.workspaceContainer} ${classes.headerSpacer}`} />
      </div>
    </RollProviders>
  );
};

export default App;
