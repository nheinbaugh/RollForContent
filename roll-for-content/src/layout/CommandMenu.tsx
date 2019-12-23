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
import ChevronLeftIcon from '@material-ui/icons/ChevronLeft';
import ChevronRightIcon from '@material-ui/icons/ChevronRight';
import Gradient from '@material-ui/icons/Gradient';
import InboxIcon from '@material-ui/icons/Inbox';
import MailIcon from '@material-ui/icons/Mail';
import React from 'react';
import { Link, LinkProps } from 'react-router-dom';
import { routes } from '../providers/RouteProvider';
import { BaseProps } from '../utils';

const useStyles = makeStyles(theme =>
  createStyles({
    root: {
      display: 'flex'
    },
    drawer: (props: CommandMenuProps) => ({
      width: props.menuWidth || '250px',
      flexShrink: 0
    }),
    drawerPaper: (props: CommandMenuProps) => ({
      width: props.menuWidth || '250px'
    }),
    drawerHeader: {
      display: 'flex',
      alignItems: 'center',
      padding: theme.spacing(0, 1),
      ...theme.mixins.toolbar,
      justifyContent: 'flex-end'
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

  closeDrawer: () => void;
}

const WrappedLink = React.forwardRef<HTMLAnchorElement, LinkProps>((props, ref) => <Link innerRef={ref} {...props} />);

const CommandMenu: React.FC<CommandMenuProps> = props => {
  const classes = useStyles(props);
  const theme = useTheme();

  return (
    <Drawer
      className={`${classes.drawer} ${props.className}`}
      variant="persistent"
      open={props.isDrawerOpen}
      anchor="left"
      classes={{
        paper: classes.drawerPaper
      }}
    >
      <div className={classes.drawerHeader}>
        <IconButton onClick={props.closeDrawer}>
          {theme.direction === 'ltr' ? <ChevronLeftIcon /> : <ChevronRightIcon />}
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
        {['Content', 'Recipes', 'Traits', 'Attribute Values'].map((text, index) => (
          <ListItem button key={text}>
            <ListItemIcon>{index % 2 === 0 ? <InboxIcon /> : <MailIcon />}</ListItemIcon>
            <ListItemText primary={text} />
          </ListItem>
        ))}
      </List>
    </Drawer>
  );
};

export default CommandMenu;
