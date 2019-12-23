import { createStyles, makeStyles } from '@material-ui/core';
import React, { useState } from 'react';
import CommandMenu from './layout/CommandMenu';
import Header from './layout/Header';
import Workspace from './layout/workspace/Workspace';
import RollProviders from './providers/RollProviders';
import DefaultTheme from './styles/DefaultTheme';

const menuWidth = 250;

const useStyles = makeStyles(theme =>
  createStyles({
    appContainer: {
      height: '100vh',
      width: '100vw'
    },
    workspaceContainer: {},
    menuDrawer: {},
    headerSpacer: theme.mixins.toolbar
  })
);

const App: React.FC = () => {
  const classes = useStyles();
  const [isDrawerOpen, setDrawerOpen] = useState(false);

  const openDrawer = () => setDrawerOpen(true);
  const closeDrawer = () => setDrawerOpen(false);
  return (
    <RollProviders theme={DefaultTheme}>
      <div className={classes.appContainer}>
        <Header openDrawer={openDrawer} isDrawerOpen={isDrawerOpen} drawerWidth={menuWidth} />
        <CommandMenu
          className={`${classes.menuDrawer} ${classes.headerSpacer}`}
          menuWidth={menuWidth}
          isDrawerOpen={isDrawerOpen}
          closeDrawer={closeDrawer}
        />
        <Workspace
          className={`${classes.workspaceContainer} ${classes.headerSpacer}`}
          isDrawerOpen={isDrawerOpen}
          drawerWidth={menuWidth}
        />
      </div>
    </RollProviders>
  );
};

export default App;
