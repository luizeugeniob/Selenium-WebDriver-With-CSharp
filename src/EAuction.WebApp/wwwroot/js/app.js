function followAuction(data, onsucess, onerror) {
    $.post(
        '/Interested/FollowAuction',
        data,
        onsucess,
        onerror
    );
}

function abandonAuction(data, onsucess, onerror) {
    $.post(
        '/Interested/AbandonAuction',
        data,
        onsucess,
        onerror
    );
}