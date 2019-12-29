import { AppBar, createStyles, IconButton, makeStyles, Theme, Toolbar, Typography } from '@material-ui/core';
import MenuIcon from '@material-ui/icons/Menu';
import clsx from 'clsx';
import React from 'react';

interface HeaderProps {
  isDrawerOpen: boolean;

  openDrawer: () => void;

  /**
   * How wide the parent drawer is. This is needed to power animation (maybe should be more public than prop drilled)
   */
  drawerWidth: number;
}

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    root: {
      flexGrow: 1
    },
    appBar: {
      transition: theme.transitions.create(['margin', 'width'], {
        easing: theme.transitions.easing.sharp,
        duration: theme.transitions.duration.leavingScreen
      })
    },
    appBarShift: (props: HeaderProps) => ({
      width: `calc(100% - ${props.drawerWidth}px)`,
      marginLeft: props.drawerWidth,
      transition: theme.transitions.create(['margin', 'width'], {
        easing: theme.transitions.easing.easeOut,
        duration: theme.transitions.duration.enteringScreen
      })
    }),
    menuButton: {
      marginLeft: theme.spacing(2)
    },
    hide: {
      display: 'none'
    },
    title: {
      flexGrow: 1
    }
  })
);

const Header: React.FC<HeaderProps> = props => {
  const { isDrawerOpen, openDrawer } = props;
  const classes = useStyles(props);
  return (
    <AppBar
      position="fixed"
      className={clsx(classes.appBar, {
        [classes.appBarShift]: isDrawerOpen
      })}
    >
      <Toolbar>
        <IconButton
          onClick={openDrawer}
          edge="start"
          className={clsx(classes.menuButton, isDrawerOpen && classes.hide)}
        >
          <MenuIcon />
        </IconButton>
        <Typography className={classes.menuButton} variant="h6">
          Roll for Content
        </Typography>
      </Toolbar>
    </AppBar>
  );
};

export default Header;
