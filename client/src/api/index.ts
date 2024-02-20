import axios from 'axios';

axios.defaults.headers.post['Access-Control-Allow-Origin'] = '*';

const api = axios.create({
    // baseURL:'http://localhost:5151/api',
    baseURL:'http://localhost:5000/api',
    headers: {
        'Access-Control-Allow-Origin': '*',
        'Content-Type': 'application/json',
    },
    timeout: 1000,
    withCredentials: true
});

export { api } 