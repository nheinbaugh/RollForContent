import { createStyles, makeStyles } from '@material-ui/core';
import React from 'react';
import { BaseProps } from '../utils';

const useStyles = makeStyles(theme =>
  createStyles({
    workspaceContainer: {
      padding: theme.spacing(2)
    }
  })
);

const Workspace: React.FC<BaseProps> = ({ className }) => {
  const classes = useStyles();
  return <div className={`${classes.workspaceContainer} ${className}`}>This is the workspace</div>;
};

export default Workspace;
