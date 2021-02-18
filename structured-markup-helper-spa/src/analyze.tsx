import React, { useState, useEffect } from 'react';
import { Box, Button, Chip, Divider, IconButton, InputBase, makeStyles, Typography, withStyles } from '@material-ui/core';
import Grid from '@material-ui/core/Grid';
import Paper from '@material-ui/core/Paper';
import {
    BrowserRouter as Router,
    Link,
    useLocation,
    useHistory
} from "react-router-dom";
import { globalConfig } from './global-config';
import SearchIcon from '@material-ui/icons/Search';
import AccountTreeOutlinedIcon from '@material-ui/icons/AccountTreeOutlined';
//import Mark from 'mark.js'
const Mark = require('mark.js');
//document.getElementById('web-frame')

interface MarkupResult {
    data?: {
        document?: {
            text: string;
        },
        mappings?: {
            iptcCategories: {
                iptcId: string;
                iptcLabel: string;
            }[],
            schemaOrgType: {
                schemaId: string;
                schemaType: string;
            },
            positions: {
                start: number;
                end: number;
            }[]
        }[]
    };
    hasError?: boolean;
    message?: string;
}

const useStyles = makeStyles((theme) => ({
    root: {
        marginTop: '1%',
        marginBottom: '1%',
        marginRight: '1%',
        marginLeft: '1%',
        padding: '1% 2%',
        display: 'flex',
        alignItems: 'center',
        width: '97%',
        boxShadow: '0 1px 14px 2px #7b7b7b'
    },
    input: {
        marginLeft: theme.spacing(1),
        flex: 1,
        fontSize: '1.2vw'
    },
    iconButton: {
        padding: 10,
        color: '#FC826A'
    },
    divider: {
        height: '1.2vw',
        margin: 4,
    },
}));

let findIndices: { [key: string]: number } = {};

function Analyze() {


    const markInstance = new Mark(document.body);

    const classes = useStyles();
    const history = useHistory();

    let query = new URLSearchParams(useLocation().search);

    let url: string = query.get("url") as string;
    let newUrl: string;

    const [markupResult, setMarkupResult] = useState<MarkupResult>({
        data: {
            mappings: []
        },
        hasError: false
    });
    const [mounted, setMounted] = useState(false);

    if (!mounted) {
        fetch(`${globalConfig.serverUrl}/markup/url-markup`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ url: url })
        }).then(response => {
            response.json().then((result: MarkupResult) => {
                if (result.hasError) {
                    window.alert(result.message);
                }
                else {
                    findIndices = {};
                    setMarkupResult(result);
                }
            })
        });
    }

    useEffect(() => {
        setMounted(true)
    }, []);

    return (
        <React.Fragment>
            <Grid container style={{ borderTop: '1px solid #ccc' }}>

                <Grid item xs={9}>

                    <Paper component="form" className={classes.root}>
                        <InputBase
                            defaultValue={url}
                            className={classes.input}
                            placeholder="Enter a Url to Analyze"
                            inputProps={{ 'aria-label': 'Url' }}
                            onChange={e => {
                                newUrl = e.target.value;
                            }}
                        />
                        <Divider className={classes.divider} orientation="vertical" />
                        <IconButton color="primary" className={classes.iconButton} aria-label="directions" onClick={() => {
                            if (newUrl) {
                                window.location.href = `/analyze?url=${newUrl}`;
                            }
                        }}>
                            <AccountTreeOutlinedIcon />
                        </IconButton>
                    </Paper>

                    <iframe id='web-frame' src={`${globalConfig.serverUrl}/markup/webpage?url=${url}`} height="100%" width="100%"></iframe>
                </Grid>

                <Grid item xs={3} style={{ padding: '10px', borderLeft: '1px solid #ccc' }}>
                    <div style={{ color: '#FC826A', fontSize: '2.2vw' }}>Schemas:</div>
                    {
                        markupResult?.data?.mappings?.map(m => {
                            return <Paper style={{ margin: '15px 0', padding: '10px' }}>
                                <Box display="flex" flexDirection="column" flexGrow="1">

                                    <Box display="flex" justifyContent="space-between" flexGrow="1">
                                        <Box display="flex" justifyContent="flex-start">
                                            <Box className="schema-link">
                                                <a href={`https://schema.org/${m.schemaOrgType.schemaType}`} target="_blank">
                                                    {m.schemaOrgType.schemaType} <span style={{ color: '#aaa', fontSize: '0.5vw' }}>(schema.org)</span>
                                                </a>
                                            </Box>
                                        </Box>
                                        <Box display="flex" justifyContent="flex-end" flexGrow="1">
                                            <Box flexDirection="column" justifyContent="flex-end">
                                                <Box display="flex">
                                                    <Chip
                                                        size="small"
                                                        icon={<SearchIcon />}
                                                        label="Find in page"
                                                        clickable
                                                        color="primary"
                                                        onClick={() => {

                                                            let findItem = findIndices[m.schemaOrgType.schemaType];
                                                            if (findItem == undefined) {
                                                                findItem = 0;
                                                                findIndices[m.schemaOrgType.schemaType] = findItem;
                                                            }
                                                            else {
                                                                findItem = (findItem + 1) % m.positions.length
                                                                findIndices[m.schemaOrgType.schemaType] = findItem;
                                                            }

                                                            let pos = m.positions[findItem];
                                                            let word = markupResult.data?.document?.text.substring(pos.start, pos.end);

                                                            (document as any).getElementById('web-frame').contentWindow.window.find(word, false, false, true, true, true, false);

                                                            // (window as any)['mark'] = markInstance;
                                                            // markInstance.unmark({
                                                            //     done: () => {
                                                            //         markInstance.mark(word, { iframes: true })
                                                            //     },
                                                            //     iframes: true
                                                            // });

                                                            // if ((window as any).find) {
                                                            //     // aString, aCaseSensitive, aBackwards, aWrapAround, aWholeWord, aSearchInFrames, aShowDialog
                                                            //     (window as any).find(word, false, false, true, true, true, false);
                                                            // }

                                                            // for (let offset of m.positions) {
                                                            //     console.log('start', offset.start, 'end', offset.end)
                                                            //     let word = markupResult.data?.document?.text.substring(offset.start, offset.end);
                                                            // }
                                                        }} />
                                                </Box>
                                            </Box>
                                        </Box>
                                    </Box>
                                    <Box display="flex" flexGrow="1" style={{ marginTop: '15px' }} flexDirection="column">

                                        <Box display="flex" style={{ color: '#CCC', fontSize: '0.5vw', marginBottom: '5px' }}>mappings with IPTC:</Box>
                                        <Box display="flex">
                                            {
                                                m.iptcCategories.map(iptc => {
                                                    return <Box>
                                                        <Chip style={{ marginLeft: '5px' }} label={iptc.iptcLabel} />
                                                    </Box>
                                                })
                                            }
                                        </Box>
                                    </Box>
                                    <Box display="flex" flexGrow="1" style={{ marginTop: '15px' }} flexDirection="column">

                                        <Box display="flex" style={{ color: '#CCC', fontSize: '0.5vw', marginBottom: '5px' }}>mapped words:</Box>
                                        <Box display="flex">
                                            {
                                                m.positions.map(pos => {
                                                    return <Box>
                                                        <Chip style={{ marginLeft: '5px' }}
                                                            color="secondary" label={markupResult.data?.document?.text.substring(pos.start, pos.end)} variant="outlined" />
                                                    </Box>
                                                })
                                            }
                                        </Box>
                                    </Box>
                                </Box>
                            </Paper>
                        })
                    }
                </Grid>

            </Grid>
        </React.Fragment>
    );

}

export default Analyze;