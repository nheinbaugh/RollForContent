import { CssBaseline, MuiThemeProvider, Theme } from '@material-ui/core';
import React, { PropsWithChildren } from 'react';

interface RollProviderProps {
  theme: Theme;
}

const RollProviders: React.FC<RollProviderProps> = ({ theme, children }: PropsWithChildren<RollProviderProps>) => {
  return (
    <>
      <CssBaseline />
      <MuiThemeProvider theme={theme}> {children} </MuiThemeProvider>
    </>
  );
};

export default RollProviders;
