function generateQRCode(url) {
    var qrCodeData = new QRCode(document.createElement("div"), {
        text: url,
        width: 128,
        height: 128,
        colorDark: "#000000",
        colorLight: "#ffffff",
    });

    var canvas = qrCodeData._oDrawing._elCanvas;
    var qrImage = canvas.toDataURL("image/png");

    var qrWindow = window.open("", "_blank");
    qrWindow.document.write(`<img src="${qrImage}" alt="QR Code" />`);
}

function copyToClipboard(text) {
    navigator.clipboard.writeText(text)
        .then(() => {
            toastr.success('Link copied to clipboard!');
        })
        .catch(err => {
            toastr.error('Failed to copy text', 'Error');
        });
}

$('#urlForm').submit(function (e) {
    e.preventDefault();

    var originalUrl = $('#LongUrl').val();
    var expirationTime = $('#Minutes').val();
    if (!originalUrl && expirationTime == 'Add expiration date') {
        toastr.error('Please enter a URL and select an expiration time.', 'Error');
        return;
    } else if (!originalUrl) {
        toastr.error('Please enter a URL.', 'Error');
        return;
    } else if (expirationTime == 'Add expiration date') {
        toastr.error('Select an expiration time.', 'Error');
        return;
    }

    $.ajax({
        url: '/URLShortener/Create',
        method: 'POST',
        data: {
            LongUrl: originalUrl,
            Minutes: expirationTime
        },
        success: function (response) {
            
            if (response.hasError) {
                toastr.error(response.errorMessage, 'Error');

            }
            else {
                var shortLink = response.result.shortUrlCode;
                var listItem = `
                <li class="d-flex align-items-center">
                    <a href="https://short.link/${shortLink}" class="text-decoration-none">https://short.link/${shortLink}</a>
                    <form method="post" asp-action="Delete" asp-controller="URLShortener" class="ms-2">
                        <input type="hidden" name="shortCode" value="${shortLink}" />
                        <button type="submit" class="btn btn-link text-danger ms-2 p-0">
                            <i class="bi bi-trash"></i>
                        </button>
                    </form>
                    <button class="btn btn-link text-primary ms-2 p-0" onclick="generateQRCode('https://short.link/${shortLink}')">
                        <i class="bi bi-qr-code"></i>
                    </button>
                    <button class="btn btn-link text-success ms-2 p-0" onclick="copyToClipboard('https://short.link/${shortLink}')">
                        <i class="bi bi-clipboard"></i>
                    </button>
                </li>
                <p style="font-size: 14px; color: #9bb7f4;">
                    This link has been clicked 0 times.
                </p>
            `;

                $('#urlList').prepend(listItem);
                $('#LongUrl').val('');
                $('#Minutes').val('Add expiration date');
                toastr.success('The link has been updated successfully! You can now access it using the first link in the sidebar.', 'Update Successful');
            }
      

        },
        error: function (xhr, status, error) {
            console.error('Error:', error);
            toastr.error('An error occurred while shortening the URL.', 'Error');
        }
    });
});

function deleteLink(shortCode) {
    $.ajax({
        url: `/URLShortener/Delete/${shortCode}`,
        method: 'DELETE',
        success: function (response) {
            toastr.success('Shortened URL deleted.', 'Delete Successful');
            setTimeout(() => {
                location.reload();
            }, 2000);
        },
        error: function (xhr, status, error) {
            console.error('Error:', error);
            toastr.error('An error occurred while deleting the URL.', 'Error');
        }
    });
}

