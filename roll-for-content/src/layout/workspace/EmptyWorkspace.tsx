import { Typography } from '@material-ui/core';
import React from 'react';

/**
 * Content displayed when there is no selection made in the main menu
 */
const EmptyWorkspace = () => {
  return (
    <div>
      <Typography variant="h3" component="h3">
        Please Select a Category
      </Typography>
    </div>
  );
};

export default EmptyWorkspace;
