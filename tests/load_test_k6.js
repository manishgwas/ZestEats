import http from 'k6/http';
import { check, sleep } from 'k6';

export let options = {
    stages: [
        { duration: '2m', target: 10000 }, // ramp up to 10,000 users
        { duration: '10m', target: 10000 }, // stay at 10,000 users
        { duration: '2m', target: 0 }, // ramp down
    ],
    thresholds: {
        http_req_duration: ['p(95)<500'], // 95% of requests < 500ms
    },
};

export default function () {
    // Simulate order placement
    let res = http.post('http://gateway/api/order', JSON.stringify({
        userId: 'test-user',
        restaurantId: 'test-restaurant',
        items: [{ menuItemId: 'item1', quantity: 2 }],
        paymentMethod: 'test',
    }), { headers: { 'Content-Type': 'application/json' } });
    check(res, { 'order placed': (r) => r.status === 200 });
    sleep(1);
    // Simulate payment
    let payRes = http.post('http://gateway/api/payment', JSON.stringify({
        orderId: res.json('orderId'),
        amount: 100,
        method: 'test',
    }), { headers: { 'Content-Type': 'application/json' } });
    check(payRes, { 'payment success': (r) => r.status === 200 });
    sleep(1);
}
