import { CssBaseline, MuiThemeProvider, Theme } from '@material-ui/core';
import React, { PropsWithChildren } from 'react';
import { BrowserRouter } from 'react-router-dom';

interface RollProviderProps {
  theme: Theme;
}

const RollProviders: React.FC<RollProviderProps> = ({ theme, children }: PropsWithChildren<RollProviderProps>) => {
  return (
    <>
      <CssBaseline />
      <MuiThemeProvider theme={theme}>
        <BrowserRouter>{children}</BrowserRouter>
      </MuiThemeProvider>
    </>
  );
};

export default RollProviders;
