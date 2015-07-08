Sandbox('googleComponent',[],function(){
	var drawImages = function(imageSearch, wraper){
        if (imageSearch.results && imageSearch.results.length > 0) {

          var contentDiv = document.getElementById(wraper);
          contentDiv.innerHTML = '';

          var results = imageSearch.results;
          for (var i = 0; i < results.length; i++) {
            
            var result = results[i];
            var imgContainer = document.createElement('div');
            var title = document.createElement('div');
            
           
            title.innerHTML = result.title;
            var newImg = document.createElement('img');

  
            newImg.src=result.tbUrl;
            imgContainer.appendChild(newImg);
            console.log(result);

            contentDiv.appendChild(imgContainer);
          }

          addPaginationLinks(imageSearch, wraper);

        }
	}

	function addPaginationLinks(imageSearch, wraper) {
        var cursor = imageSearch.cursor;
        var curPage = cursor.currentPageIndex;
        var pagesDiv = document.createElement('div');
        for (var i = 0; i < cursor.pages.length; i++) {
          console.log(cursor.pages.length)
          var page = cursor.pages[i];
          if (curPage == i) { 
            var label = document.createTextNode(' ' + page.label + ' ');
            pagesDiv.appendChild(label);
          } else {
            var link = document.createElement('a');
            link.index = i;
            link.addEventListener('click', function(event){
              var element = event.target;
              console.log(event);
              console.log(event.target);
              console.log(element.index);
              imageSearch.gotoPage(element.index);
            });
            link.innerHTML = page.label;
            link.style.marginRight = '2px';
            pagesDiv.appendChild(link);
          }
        }

        var contentDiv = document.getElementById(wraper);
        contentDiv.appendChild(pagesDiv);
      }

	return {
		drawImages:drawImages
	}
});