import http from 'k6/http';
import { check, sleep } from 'k6';

export let options = {
    vus: 10000,
    duration: '1m',
    thresholds: {
        http_req_duration: ['p(95)<500'],
    },
};

export default function () {
    let res = http.post('http://localhost:5000/api/order', { /* order payload */ });
    check(res, { 'status was 200': (r) => r.status == 200 });
    sleep(0.06); // ~1000 orders/min
}
