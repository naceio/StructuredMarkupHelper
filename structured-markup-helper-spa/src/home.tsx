import React from 'react';
import { Box, Button, Divider, IconButton, InputBase, makeStyles, Typography, withStyles } from '@material-ui/core';
import Grid from '@material-ui/core/Grid';
import Paper from '@material-ui/core/Paper';
import AccountTreeOutlinedIcon from '@material-ui/icons/AccountTreeOutlined';
import Landing from './contents/landing.svg';
import { useHistory } from 'react-router-dom';

const useStyles = makeStyles((theme) => ({
    root: {
        marginTop:'7%',
        padding: '1% 2%',
        display: 'flex',
        alignItems: 'center',
        width: '100%',
        boxShadow: '0 1px 14px 2px #7b7b7b'
    },
    input: {
        marginLeft: theme.spacing(1),
        flex: 1,
        fontSize: '1.2vw'
    },
    iconButton: {
        padding: 10,
        color:'#FC826A'
    },
    divider: {
        height: '1.2vw',
        margin: 4,
    },
}));

function Home() {
    const classes = useStyles();
    const history = useHistory();

    let url:string;

    return (
        <React.Fragment>
                <Grid item xs={5}>
                    <div className="main-container">
                        <Grid item xs={12}>
                            <h1 className="main-title">
                            Structured Markup Generator
                        </h1>
                            <p className="main-par">
                                Schema.org is the result of collaboration between Google, Bing, Yandex, and Yahoo!
                                to improve the web by creating a structured data markup schema supported by major search engines. On-page markup helps search engines understand the information on web pages and provide richer search results
                               
                        </p>
                        <p className="second-par">
                            Markup expert will help you to generate structured-data markup by analyzing the content of your webpage, powered by 
                            <a href="https://www.expert.ai/" target="_blank">expert.ai</a>
                        </p>
                        </Grid>

                        <Grid item xs={12}>
                            <Paper component="form" className={classes.root}>
                                <InputBase
                                    className={classes.input}
                                    placeholder="Enter a Url to Analyze"
                                    inputProps={{ 'aria-label': 'Url' }}
                                    onChange={e=>{
                                        url = e.target.value;
                                    }}
                                />
                                <Divider className={classes.divider} orientation="vertical" />
                                <IconButton color="primary" className={classes.iconButton} aria-label="directions" onClick={()=>{
                                    if(url){
                                        history.push(`/analyze?url=${url}`);
                                    }
                                }}>
                                    <AccountTreeOutlinedIcon />
                                </IconButton>
                            </Paper>
                        </Grid>


                    </div>
                </Grid>
                <Grid item xs={7}>
                    <div className="landing-container">
                        <img src={Landing} />
                    </div>
                </Grid>
        </React.Fragment>
    )
}

export default Home;