import React from 'react';
import AppLogo from './contents/app-logo.svg';
import './app.scss';
import { Box, Button, Divider, IconButton, InputBase, makeStyles, Typography, withStyles } from '@material-ui/core';
import Grid from '@material-ui/core/Grid';
import Paper from '@material-ui/core/Paper';
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link
} from "react-router-dom";
import Home from './home';
import Analyze from './analyze';



function App() {

    return (
        <React.Fragment>
            <Router>
                <Grid container>
                    <Grid item xs={12} style={{ height: 105, overflow: 'hidden' }}>
                        <Box display="flex" justifyContent="space-between">
                            <Box display="flex" justifyContent="flex-start">
                                <Link to='/'><img src={AppLogo} className="app-logo" /></Link>
                            </Box>
                            <Box display="flex" justifyContent="flex-end" flexGrow="1" className="menu-container">
                                <Box className="menu-link">
                                    <a href="https://github.com/naceio/StructuredMarkupHelper" target="_blank">github</a>
                                </Box>
                                <Box className="menu-link">
                                    <a href="https://www.expert.ai/" target="_blank">expert.ai</a>
                                </Box>
                            </Box>
                        </Box>
                    </Grid>
                    <Route path="/analyze" exact>
                        <Analyze />
                    </Route>
                    <Route path="/" exact>
                        <Home />
                    </Route>


                </Grid>
            </Router>
        </React.Fragment >
    );
}

export default App;
