let dataset = [];

async function loadData() {
  const size = document.getElementById("datasetSize").value;

  if (mode === "server") {
    filter();
  } else {
    const res = await fetch(`http://localhost:5206/dataset/client/${size}`);
    clientDataset = await res.json();
    renderTable(clientDataset.slice(0, 100));
  }
}

function clientFilter(term) {
  const filtered = dataset.filter((track) =>
    track.artist.toLowerCase().includes(term.toLowerCase()),
  );

  renderTable(filtered);
}

async function serverFilter(term) {
  const response = await fetch(`/api/tracks?search=${term}`);
  const data = await response.json();

  renderTable(data);
}

function filter() {
  const term = document.getElementById("search").value;
  const mode = document.querySelector('input[name="mode"]:checked').value;

  if (mode === "client") {
    clientFilter(term);
  } else {
    serverFilter(term);
  }
}

const toggle = document.getElementById("toggleMode");
const modeLabel = document.getElementById("modeLabel");

toggle.addEventListener("change", () => {
  modeLabel.textContent = toggle.checked ? "Server-side" : "Client-side";
  loadData(); // herlaad de data direct bij wisselen
});
