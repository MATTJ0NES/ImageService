# ImageService
Standalone image host with dynamic resizing. Accepts file upload via API (with key).

Images can be uploaded via api/Image/UploadImage. You will need to set an API Key in your app settings.

Images uploaded should use a numerical system for file names e.g. 1234.jpg. The service will then create a folder structure derived from this filename which ensures that folders don't become too full at scale, which can result in performance issues.
