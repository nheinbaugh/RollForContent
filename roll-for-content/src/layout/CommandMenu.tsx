import {
  createStyles,
  Divider,
  Drawer,
  IconButton,
  List,
  ListItem,
  ListItemIcon,
  ListItemText,
  makeStyles,
  useTheme
} from '@material-ui/core';
import CategoryIcon from '@material-ui/icons/Category';
import ChevronLeftIcon from '@material-ui/icons/ChevronLeft';
import ChevronRightIcon from '@material-ui/icons/ChevronRight';
import Gradient from '@material-ui/icons/Gradient';
import HelpOutlineIcon from '@material-ui/icons/HelpOutline';
import OutdoorGrillIcon from '@material-ui/icons/OutdoorGrill';
import PaletteIcon from '@material-ui/icons/Palette';
import clsx from 'clsx';
import React from 'react';
import { Link, LinkProps } from 'react-router-dom';
import { routes } from '../providers/RouteProvider';
import { BaseProps } from '../utils';

const drawerWidth = '250px';
const useStyles = makeStyles(theme =>
  createStyles({
    root: {
      display: 'flex'
    },
    drawer: (props: CommandMenuProps) => ({
      width: props.menuWidth || drawerWidth,
      flexShrink: 0
    }),
    drawerPaper: (props: CommandMenuProps) => ({
      width: props.menuWidth || drawerWidth
    }),
    drawerHeader: {
      display: 'flex',
      alignItems: 'center',
      padding: theme.spacing(0, 1),
      ...theme.mixins.toolbar,
      justifyContent: 'flex-end'
    },
    drawerOpen: {
      width: drawerWidth,
      transition: theme.transitions.create('width', {
        easing: theme.transitions.easing.sharp,
        duration: theme.transitions.duration.enteringScreen
      })
    },
    drawerClose: {
      transition: theme.transitions.create('width', {
        easing: theme.transitions.easing.sharp,
        duration: theme.transitions.duration.leavingScreen
      }),
      overflowX: 'hidden',
      width: theme.spacing(7) + 1,
      [theme.breakpoints.up('sm')]: {
        width: theme.spacing(9) + 1
      }
    },
    toolbar: theme.mixins.toolbar
  })
);

interface CommandMenuProps extends BaseProps {
  /**
   * Passed in to allow for the parent to drive the width uniformly
   */
  menuWidth?: number;

  isDrawerOpen: boolean;

  toggleDrawer: () => void;
}

const WrappedLink = React.forwardRef<HTMLAnchorElement, LinkProps>((props, ref) => <Link innerRef={ref} {...props} />);

const CommandMenu: React.FC<CommandMenuProps> = props => {
  const classes = useStyles(props);
  const theme = useTheme();

  return (
    <Drawer
      variant="permanent"
      open={props.isDrawerOpen}
      anchor="left"
      className={clsx(classes.drawer, props.className, {
        [classes.drawerOpen]: props.isDrawerOpen,
        [classes.drawerClose]: !props.isDrawerOpen
      })}
      classes={{
        paper: clsx({
          [classes.drawerOpen]: props.isDrawerOpen,
          [classes.drawerClose]: !props.isDrawerOpen
        })
      }}
    >
      <div className={classes.drawerHeader}>
        <IconButton onClick={props.toggleDrawer}>
          {props.isDrawerOpen ? <ChevronLeftIcon /> : <ChevronRightIcon />}
        </IconButton>
      </div>
      <Divider />
      <List>
        <ListItem button component={WrappedLink} key="Created Content" to={routes.content}>
          <ListItemIcon>
            <Gradient />
          </ListItemIcon>
          <ListItemText primary="Created Content" />
        </ListItem>
        <ListItem button component={WrappedLink} key="Recipes" to={routes.recipes}>
          <ListItemIcon>
            <OutdoorGrillIcon />
          </ListItemIcon>
          <ListItemText primary="Recipes" />
        </ListItem>
        <ListItem button component={WrappedLink} key="Traits" to={routes.traits}>
          <ListItemIcon>
            <PaletteIcon />
          </ListItemIcon>
          <ListItemText primary="Traits" />
        </ListItem>
        <ListItem button component={WrappedLink} key="Attribute Values" to={routes.attributes}>
          <ListItemIcon>
            <CategoryIcon />
          </ListItemIcon>
          <ListItemText primary="Attribute Values" />
        </ListItem>
        <ListItem button component={WrappedLink} key="Help" to={routes.help}>
          <ListItemIcon>
            <HelpOutlineIcon />
          </ListItemIcon>
          <ListItemText primary="Help" />
        </ListItem>
      </List>
    </Drawer>
  );
};

export default CommandMenu;
