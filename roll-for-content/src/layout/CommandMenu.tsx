import { createStyles, Drawer, List, ListItem, ListItemIcon, ListItemText, makeStyles } from '@material-ui/core';
import InboxIcon from '@material-ui/icons/Inbox';
import MailIcon from '@material-ui/icons/Mail';
import React from 'react';
import { BaseProps } from '../utils';

const useStyles = makeStyles(
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
    })
  })
);

interface CommandMenuProps extends BaseProps {
  /**
   * Passed in to allow for the parent to drive the width uniformly
   */
  menuWidth?: string;
}

const CommandMenu: React.FC<CommandMenuProps> = props => {
  const classes = useStyles(props);

  return (
    <Drawer
      className={`${classes.drawer} ${props.className}`}
      variant="permanent"
      classes={{
        paper: classes.drawerPaper
      }}
    >
      <List>
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
