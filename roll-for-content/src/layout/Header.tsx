import { AppBar, createStyles, makeStyles, Theme, Toolbar, Typography } from '@material-ui/core';
import React from 'react';

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    root: {
      flexGrow: 1
    },
    appBar: {
      zIndex: theme.zIndex.drawer + 1
    },
    menuButton: {
      marginLeft: theme.spacing(2)
    },
    title: {
      flexGrow: 1
    }
  })
);

const Header: React.FC = () => {
  const classes = useStyles();
  return (
    <AppBar className={classes.appBar} position="fixed">
      <Toolbar>
        <Typography className={classes.menuButton} variant="h6">
          Roll for Content
        </Typography>
      </Toolbar>
    </AppBar>
  );
};

export default Header;
