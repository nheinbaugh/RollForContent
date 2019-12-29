import { createStyles, makeStyles } from '@material-ui/core';
import clsx from 'clsx';
import React from 'react';
import RouteProvider from '../../providers/RouteProvider';
import { BaseProps } from '../../utils';

interface WorkspaceProps extends BaseProps {
  drawerWidth: number;

  /**
   * If the drawer is open... yea this should be a context provider
   */
  isDrawerOpen: boolean;
}

const useStyles = makeStyles(theme =>
  createStyles({
    workspaceContainer: () => ({
      flexGrow: 1,
      padding: theme.spacing(3),
      transition: theme.transitions.create('margin', {
        easing: theme.transitions.easing.sharp,
        duration: theme.transitions.duration.leavingScreen
      })
    }),
    closedDrawerWorkspace: (props: WorkspaceProps) => ({
      marginLeft: theme.spacing(7) + 1
    }),
    workspaceContainerShift: (props: WorkspaceProps) => ({
      transition: theme.transitions.create('margin', {
        easing: theme.transitions.easing.easeOut,
        duration: theme.transitions.duration.enteringScreen
      }),
      marginLeft: props.drawerWidth
    })
  })
);

const Workspace: React.FC<WorkspaceProps> = props => {
  const classes = useStyles(props);
  return (
    <div
      className={clsx(classes.workspaceContainer, {
        [classes.closedDrawerWorkspace]: !props.isDrawerOpen,
        [classes.workspaceContainerShift]: props.isDrawerOpen
      })}
    >
      <RouteProvider></RouteProvider>
    </div>
  );
};

export default Workspace;
